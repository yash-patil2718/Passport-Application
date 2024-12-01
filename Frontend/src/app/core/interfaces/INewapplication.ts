

export interface IServiceRequired{
    applicationType     : number ,
    pagesRequried       : number,
    validityRequired    : number,
    reasonforRenewal?    : number ,
    changeInAppearance?  : number
}


export interface IApplicantDetails{

    applicantFirstName      : string,
    applicantLastName       : string,
    isAliases               : boolean,
    aliasName               : string,
    isChangedName           : boolean,
    previousName            : string,
    dob                     : Date
    placeOfBirth            : string,
    gender                  : number,
    district                : string,
    state                   : number,
    country                 : number,
    pancardNo               : string,
    voterIdNo               : string,
    aadharcardNo            : string,
    maritalStatus           : number,
    employementType         : number,
    organizationName?        : string,
    isParentOrSpouceGovermentServent: boolean,
    educationQualification  : number,
    citizenship             : number,
    isNonEcrEligible        : boolean,
    distinguishMark         : string,
    previousPassportNumber?  : string,
    dateOfIssue?             : Date,
    placeOfIssue?            : string
}

export interface IFamilyDetails{
    fatherFirstName             : string,
    fatherSurname               : string,
    motherFirstName             : string,
    motherSurname               : string,
    leagalGuardianFirstName     : string,
    leagalGuardianSurname       : string,
    spouceFirstName             : string,
    spouceSurname               : string
}

export interface IResidentialDetails{
    houseNoAndName              : string,
    addressLane1                : string,
    addressLane2                : string
    villageOrCityName           : string,
    district                    : string,
    state                       : number,
    country                     : number,
    pincode                     : string,
    mobileNo                    : string,
    telephoneNo                 : string
}

export interface IEmergencyContactDetails{
    emergencyContactName        : string,
    emergencyContactAddress     : string,
    emergencyContactMobileNo    : string,
    emergencyContactEmail       : string,
    emergencyContactCity        : string,
    pincode                     : string,
    district                    : string,
    state                       : number
}

export interface IOtherDetails{
    isCriminalProceedings     : boolean,
    isWarrantSummons          : boolean,
    iArrestWarrant            : boolean,
    isDepartureOrder          : boolean,
    iConviction               : boolean,
    isPassportRefusal         : boolean,
    isPassportImpounded       : boolean,
    ispassportRevoked         : boolean,
    isForeignCitizenship      : boolean,
    isotherPassport           : boolean,
    isSurrenderedPassport     : boolean,
    isRenunciation            : boolean,
    isEmergencyCertificate    : boolean,
    isDeported                : boolean,
    isRepatriated             : boolean
}

export interface IDocumentDetails{
    isAcceptTermsAndCondition   : boolean,
    place                       : string,
    dateOfAppApplied            : Date
}

export interface INewApplicationForm{
    userId                  : number,
    applicationNo           : string,
    serviceRequiredDto      : IServiceRequired,
    applicntDetailsDto      : IApplicantDetails,
    familyDetailsDto        : IFamilyDetails,
    residentialDetailsDto   : IResidentialDetails,
    emergencyDetailsDto     : IEmergencyContactDetails,
    otherDetailsDto         : IOtherDetails,
    documentsDto            : IDocumentDetails
}