import React from "react";
import type { FC, ReactNode } from "react";

import { useEffect } from "react";
import { motion, useAnimation } from "framer-motion";
import { useInView } from "react-intersection-observer";

// Material
import { Box } from "@material-ui/core";

// interfaces
interface IMotionViewProps {
  children?: ReactNode;
  variants: { [key: string]: any };
  transition?: { [key: string]: any };
  threshold?: number | Array<number>;
}

export const MotionInView: FC<IMotionViewProps> = ({
  children,
  variants,
  transition,
  threshold,
  ...other
}) => {
  const controls = useAnimation();
  const [ref, inView] = useInView({
    threshold: threshold || 0,
    triggerOnce: true,
  });

  useEffect(() => {
    if (inView) {
      controls.start(Object.keys(variants)[1]);
    } else {
      controls.start(Object.keys(variants)[0]);
    }
  }, [controls, inView, variants]);

  return (
    <Box
      ref={ref}
      component={motion.div}
      initial={Object.keys(variants)[0]}
      animate={controls}
      variants={variants}
      transition={transition}
      {...other}
    >
      {children}
    </Box>
  );
};
