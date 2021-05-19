import _ from "lodash";
import { colors, createTheme, responsiveFontSizes } from "@material-ui/core";
import type { Theme as MuiTheme } from "@material-ui/core/styles/";
import type { Shadows as MuiShadows } from "@material-ui/core/styles/shadows";
import type {
  Palette as MuiPalette,
  TypeBackground as MuiTypeBackground,
} from "@material-ui/core/styles/createPalette";

// Custom Components
import { THEMES } from "../constants";
import { softShadows, strongShadows } from "./shadows";
import typography from "./typography";

interface TypeBackground extends MuiTypeBackground {
  dark: string;
  default: any; // @TODO: to change
}

interface Palette extends MuiPalette {
  background: TypeBackground;
}

export interface Theme extends MuiTheme {
  name: string;
  palette: Palette;
  spacing: any; // @TODO: to change
}

type Direction = "ltr" | "rtl";

interface ThemeConfig {
  direction?: Direction;
  responsiveFontSizes?: boolean;
  theme?: string;
}

interface ThemeOptions {
  name?: string;
  direction?: Direction;
  typography?: Record<string, any>;
  overrides?: Record<string, any>;
  layout?: Record<string, any>;
  palette?: Record<string, any>;
  shadows?: MuiShadows;
}

const baseOptions: ThemeOptions = {
  direction: "ltr",
  typography,
  layout: {
    contentWidth: 1140,
  },
  overrides: {
    MuiLinearProgress: {
      root: {
        borderRadius: 3,
        overflow: "hidden",
      },
    },
    MuiListItemIcon: {
      root: {
        minWidth: 32,
      },
    },
    MuiChip: {
      root: {
        backgroundColor: "rgba(0,0,0,0.075)",
      },
    },
  },
};

const themesOptions: ThemeOptions[] = [
  {
    name: THEMES.LIGHT,
    overrides: {
      MuiInputBase: {
        input: {
          "&::placeholder": {
            opacity: 1,
            color: colors.blueGrey[600],
          },
        },
      },
    },
    palette: {
      type: "light",
      action: {
        active: colors.blueGrey[600],
      },
      background: {
        default: colors.common.white,
        dark: "#f4f6f8",
        paper: colors.common.white,
      },
      primary: {
        main: "#A7131D",
      },
      secondary: {
        main: "#005D28",
      },
      text: {
        primary: colors.blueGrey[900],
        secondary: colors.blueGrey[600],
      },
      white: {
        main: "#FFF",
      },
    },
    shadows: softShadows,
  },
  {
    name: THEMES.ONE_DARK,
    palette: {
      type: "dark",
      action: {
        active: "rgba(255, 255, 255, 0.54)",
        hover: "rgba(255, 255, 255, 0.04)",
        selected: "rgba(255, 255, 255, 0.08)",
        disabled: "rgba(255, 255, 255, 0.26)",
        disabledBackground: "rgba(255, 255, 255, 0.12)",
        focus: "rgba(255, 255, 255, 0.12)",
      },
      background: {
        default: "#282C34",
        dark: "#1c2025",
        paper: "#282C34",
      },
      primary: {
        main: "#8a85ff",
      },
      secondary: {
        main: "#8a85ff",
      },
      text: {
        primary: "#e6e5e8",
        secondary: "#adb0bb",
      },
      white: {
        main: "#FFF",
      },
    },
    shadows: strongShadows,
  },
];

export const createAppTheme = (config: ThemeConfig = {}): Theme => {
  let themeOptions = themesOptions.find((theme) => theme.name === config.theme);

  if (!themeOptions) {
    [themeOptions] = themesOptions;
  }

  let theme = createTheme(
    _.merge({}, baseOptions, themeOptions, { direction: config.direction })
  );

  if (config.responsiveFontSizes) {
    theme = responsiveFontSizes(theme);
  }

  return theme as Theme;
};
