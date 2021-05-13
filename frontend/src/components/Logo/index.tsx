import React from "react";
import type { FC } from "react";
import Typography from "@material-ui/core/Typography";

interface LogoProps {
  [key: string]: any;
}

const Logo: FC<LogoProps> = (props) => {
  const logo =
    props && props.name ? (
      <Typography variant="h2" color="primary" className="logoName">
        {props.name}
      </Typography>
    ) : (
      <img
        className="logo"
        alt="Logo"
        src="/static/logo.png"
        height="35"
        {...props}
      />
    );

  return <>{logo}</>;
};

export default Logo;
