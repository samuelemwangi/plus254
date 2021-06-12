import React from "react";
import { render, screen } from "@testing-library/react";
import App from "./App";

test("renders app - plus254", () => {
  render(<App />);
  const mainText = screen.queryAllByText(/plus254/i);

  expect(mainText.length).toBeGreaterThan(1);
});
