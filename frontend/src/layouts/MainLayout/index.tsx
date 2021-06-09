import React from "react";
import type { FC, ReactNode } from "react";

// material
import { Box } from "@material-ui/core";

//custom components
import Navbar from "./Navbar";
import Footer from "./Footer";

// interfaces
interface IMainLayoutProps {
  children?: ReactNode;
}

const MainLayout: FC<IMainLayoutProps> = ({ children }) => {
  return (
    <Box sx={{ height: "100%" }}>
      <Navbar />
      <Box sx={{ height: "100%" }}>
        {children}
        <Footer />
      </Box>
    </Box>
  );
};

export default MainLayout;
