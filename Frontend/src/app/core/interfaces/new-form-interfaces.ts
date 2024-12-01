// form-interfaces.ts

import { ApplicationStatus } from "../enums/applicationStatus";
import { Payment } from "../enums/payment";



export interface ServiceRequest {
    applicationType: string;
    passportPages: string;
    validityPeriod: string;
}

export interface Applicant {
    applicantName: string;
    applicantSurName: string;
    aliases: string;
    alias_names:string;
    changedname: string;
    previous_name:string;
    dob: string;
    placeOfBirth: string;
    gender: string;
    district: string;
    state: string;
    country: string;
    pan: string;
    voterId: string;
    maritalStatus: string;
    employmentType: string;
    organizationName: string;
    parentOrSpouseGovServant: string;
    educationQualification: string;
    nonEcrEligible: string;
    distinguishingMark: string;
    aadhaarNumber: string;
}

export interface Feedback {
    fatherName: string;
    fatherSurname: string;
    motherName: string;
    motherSurname: string;
    legalGuardianName: string;
    legalGuardianSurname: string;
    spouseName: string;
    spouseSurname: string;
}

export interface AddressDetails {
    houseNumber: string;
    address_lane1: string,
    address_lane2?: string,
    city: string;
    district: string;
    state: string;
    pin: string;
    country: string;
    mobileNumber: string;
    telephoneNumber: string;
}

export interface Emergency {
    emergencyDetailName: string;
    emergencyDetailAddress: string;
    emergencyDetailMobileNo: string;
    emergencyDetailEmail: string;
    emergencyDetailCity: string;
    district: string;
    pin: string;
    emergencyDetailState: string;
}

export interface Questions {
    criminalProceedings: string;
    warrantSummons: string;
    arrestWarrant: string;
    departureOrder: string;
    conviction: string;
    passportRefusal: string;
    passportImpounded: string;
    passportRevoked: string;
    foreignCitizenship: string;
    otherPassport: string;
    surrenderedPassport: string;
    renunciation: string;
    emergencyCertificate: string;
    deported: string;
    repatriated: string;
}

export interface Declaration {
    chkDeclaration: boolean;
    placeOfApply: string;
    dateOfApply: string;
}


export interface NewApplicationData {
    id?:string;
    applicationNumber: string;
    status: ApplicationStatus // true for completed, false for pending
    payment: Payment;
    serviceRequest: ServiceRequest;
    applicant: Applicant;
    feedback: Feedback;
    address: AddressDetails;
    emergency: Emergency;
    questions: Questions;
    declaration: Declaration;
    isEditing?:boolean; 
}
  