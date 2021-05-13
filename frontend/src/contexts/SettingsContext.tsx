import React, { createContext, useState, useEffect } from "react";
import type { FC, ReactNode } from "react";
import _ from "lodash";
import { THEMES } from "../constants";

interface Settings {
  direction?: "ltr" | "rtl";
  responsiveFontSizes?: boolean;
  theme?: string;
}

export interface SettingsContextValue {
  settings: Settings;
  saveSettings: (update: Settings) => void;
}

interface SettingsProviderProps {
  settings?: Settings;
  children?: ReactNode;
}

// Define Default settings
const defaultSettings: Settings = {
  direction: "ltr",
  responsiveFontSizes: true,
  theme: THEMES.LIGHT,
};

// Read Settings from Local Storage
export const restoreSettings = (): Settings | null => {
  let settings = null;

  try {
    const storedData: string | null = window.localStorage.getItem("settings");
    if (storedData) {
      settings = JSON.parse(storedData);
    }
  } catch (error) {
    // eslint-disable-next-line no-console
    console.error(error);
  }

  return settings;
};

// Store settings to Local Storage
export const storeSettings = (settings: Settings): void => {
  window.localStorage.setItem("settings", JSON.stringify(settings));
};

const SettingsContext = createContext<SettingsContextValue>({
  settings: defaultSettings,
  saveSettings: () => {},
});

export const SettingsProvider: FC<SettingsProviderProps> = ({
  settings,
  children,
}) => {
  const [currentSettings, setCurrentSettings] = useState<Settings>(
    settings || defaultSettings
  );

  const handleSaveSettings = (update: Settings = {}): void => {
    const mergedSettings = _.merge({}, currentSettings, update);

    setCurrentSettings(mergedSettings);
    storeSettings(mergedSettings);
  };

  useEffect(() => {
    const restoredSettings = restoreSettings();

    if (restoredSettings) {
      setCurrentSettings(restoredSettings);
    }
  }, []);

  useEffect(() => {
    document.dir =
      currentSettings.direction === undefined
        ? "ltr"
        : currentSettings.direction;
  }, [currentSettings]);

  return (
    <SettingsContext.Provider
      value={{
        settings: currentSettings,
        saveSettings: handleSaveSettings,
      }}
    >
      {children}
    </SettingsContext.Provider>
  );
};

export const SettingsConsumer = SettingsContext.Consumer;

export default SettingsContext;
