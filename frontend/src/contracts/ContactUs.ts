export interface IContactUsPayload {
  name: string;
  email: string;
  mobile: string;
  desc: string;
}

export interface IContactUsPayloadAction {
  type: string;
  payload: IContactUsPayload;
}

export interface IContactUsResponse {
  [key: string]: any;
}

export interface IContactUsResponseAction {
  type: string;
  payload: IContactUsResponse;
}
