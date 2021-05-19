import React from "react";
import type { FC } from "react";

// Material
import { Typography } from "@material-ui/core";
import { experimentalStyled as styled } from "@material-ui/core/styles";

// Interfaces
interface LogoProps {
  [key: string]: any;
}

// Styles
const TypographyStyle = styled(Typography)(() => ({}));
const ImageStyle = styled("img")(() => ({}));

// Main component
const Logo: FC<LogoProps> = (props) => {
  const logo =
    props && props.name ? (
      <TypographyStyle variant="h2" color="primary">
        {props.name}
      </TypographyStyle>
    ) : (
      <ImageStyle alt="Logo" src="/static/logo.png" height="35" {...props} />
    );

  return <>{logo}</>;
};

export default Logo;
