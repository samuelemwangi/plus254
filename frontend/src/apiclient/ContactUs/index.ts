import ApiClientEndPointMethod from "../EndPoint";
import {
  IContactUsPayload,
  IContactUsResponse,
} from "../../contracts/ContactUs";
import { BACKEND_BASE_URL } from "../EndPoint/ConstantVariables";

export const updateContactUs = (
  payload: IContactUsPayload
): IContactUsResponse => {
  const contactUsUpdate = ApiClientEndPointMethod({
    customBodyOptions: {
      body: JSON.stringify(payload),
    },
    url: BACKEND_BASE_URL + "hireus",
    method: "POST",
  });

  try {
    return contactUsUpdate.then((hs) => {
      if (hs && hs.requestStatus === 1) {
        return { data: "Request sent successfully. " };
      } else {
        return {
          error:
            "A system error occured while sending your request. Please retry ",
        };
      }
    });
  } catch (error) {
    return { error: "An error occured while sending the request" };
  }
};
