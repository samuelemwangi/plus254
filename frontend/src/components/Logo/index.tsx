import React from "react";
import type { FC } from "react";

// Material
import { Typography, experimentalStyled as styled } from "@material-ui/core";

// Styles
const TypographyStyle = styled(Typography)(() => ({}));

const ImageStyle = styled("img")(() => ({}));

// Interfaces
interface ILogoProps {
  [key: string]: any;
}

// Main component
const Logo: FC<ILogoProps> = (props) => {
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
