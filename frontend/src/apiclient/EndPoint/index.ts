/* global  fetch,Request, localStorage */
import { MY_TOKEN_KEY } from "./ConstantVariables";

export const getAuthToken = () => localStorage.getItem(MY_TOKEN_KEY);

interface ApiClientEndPointMethodArgsTypes {
  customHeaders?: HeadersInit;
  url: string;
  method?: string;
  customBodyOptions?: { [key: string]: string };
  authorize?: boolean;
}

interface RequestType {
  method: string;
  headers: HeadersInit;
  mode: RequestMode;
  redirect: RequestRedirect;
  referrer: string;
}

const ApiClientEndPointMethod = ({
  customHeaders = {},
  url = "",
  method = "GET",
  customBodyOptions = {},
  authorize = false,
}: ApiClientEndPointMethodArgsTypes): Promise<any> => {
  let requestHeaders = {
    Accept: "application/json",
  };

  if (authorize) {
    requestHeaders = {
      ...requestHeaders,
    };
  }

  // set request header to application/json when it is not a form
  if (
    customBodyOptions &&
    customBodyOptions.body &&
    typeof customBodyOptions.body === "string"
  ) {
    requestHeaders = {
      ...requestHeaders,
      ...{ "Content-Type": "application/json" },
    };
  }

  const requestInit: RequestType = {
    ...{
      method,
      headers: { ...requestHeaders, ...customHeaders },
      mode: "cors",
      redirect: "follow",
      referrer: "no-referrer",
    },
    ...customBodyOptions,
  };

  const apiClientRequest = new Request(url, requestInit);

  return fetch(apiClientRequest)
    .then((response) => {
      if (response.status >= 200 && response.status < 300) {
        return Promise.resolve(response);
      }
      return Promise.reject(new Error(response.statusText));
    })
    .then((response) => {
      return response.json();
    })
    .then((responseData) => {
      return responseData;
    })
    .catch((error) => {
      return { Error: error.message };
    });
};

export default ApiClientEndPointMethod;

// https://microsoft.github.io/PowerBI-JavaScript/interfaces/_node_modules_typedoc_node_modules_typescript_lib_lib_dom_d_.request.html
