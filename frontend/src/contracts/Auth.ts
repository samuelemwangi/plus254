export interface ILoginPayload {
  email?: string;
  password?: string;
}

export interface IRegisterPayload {
  email?: string;
  fullName?: string;
  password?: string;
  confirmPassword?: string;
}
