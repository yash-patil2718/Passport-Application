import { Role } from "../enums/role";

export interface User {
    id: number;
    firstname: string;
    middlename: string;
    lastname: string;
    dob: string;
    email: string;
    gender: string;
    mobile: string;
    username: string;
    password: string;
    confirmpassword: string;
    agree: boolean;
    role: Role; //true = admin, false == user
  }