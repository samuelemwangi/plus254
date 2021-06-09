const path = (link: string, subLink: string) => link + "/" + subLink;

const ROOT_AUTH = "/auth";
const ROOT_MAIN = "";
const ROOT_EXPLORE = "/explore";
const ROOT_ERROR = "";

export const PATHS = {
  // Auth
  LOGIN: path(ROOT_AUTH, "login"),
  REGISTER: path(ROOT_AUTH, "register"),
  FORGOT_PASSWORD: path(ROOT_AUTH, "forgot-password"),

  // MAIN
  HOME: path(ROOT_MAIN, ""),
  ABOUT_US: path(ROOT_MAIN, "about-us"),
  CONTACT_US: path(ROOT_MAIN, "contact-us"),

  // Explore
  EXPLORE: path(ROOT_EXPLORE, ""),

  // Errors
  ERROR_404: path(ROOT_ERROR, "404"),
  ERROR_500: path(ROOT_ERROR, "500"),
};
