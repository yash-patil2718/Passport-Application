export enum ApplicationStatus
{
    New          = 0,
    Pending      = 1,
    InProcess    = 2,
    Approved     = 3,
}

export enum ApplicationType
{
    Normal = 0,
    Tatkal = 1
}

export enum ChangeInAppearance
{
    Appearance      = 0,
    Signature       = 1,
    GivenName       = 2,
    Surname         = 3,
    DateOfBirth     = 4,
    SpouseName      = 5,
    Address         = 6,    
    DeleteECR       = 7
}

export enum Citizenship
{
    ByBirth = 0,
    ByDescent = 1,
    ByRegistrationNaturalization = 2,
}

export enum Country
{
    Argentina       = 0,
    Australia       = 1,
    Brazil          = 2,
    Canada          = 3,
    China           = 4,
    France          = 5,
    Germany         = 6,
    India           = 7,
    Japan           = 8,
    Malaysia        = 9,
    Mexico           = 10,
    NewZealand      = 11,
    Russia          = 12,
    SaudiArabia     = 13,
    Singapore       = 14,
    SouthAfrica     = 15,
    SouthKorea      = 16,
    UnitedArabEmirates = 17,
    UnitedKingdom   = 18,
    USA             = 19
}


export enum EducationalQualification
{
    SeventhPassOrLess   = 0,
    BetweenEigthandNine = 1,
    TenthPassandAbove   = 2,
    GraduateAndAbove    = 3,

}

export enum EmployeementType
{
    PSU                         = 0,
    Government                  = 1,
    StatutoryBody               = 2,
    RetiredGovernmentServant    = 3,
    SelfEmployed                = 4,
    Private                     = 5,
    Homemaker                   = 6,
    NotEmployed                 = 7,
    RetiredPrivateService       = 8,
    Student                     = 9,
    Other                       = 10
}

export enum FeedbackEnum
{
    New         = 0,
    Pending     = 1,
    Inprocess   = 2,
    Resolved    = 3,
}

export enum MaritalStatus
{
    Single = 0,
    Married = 1,
    WidoworWidower = 2,
    Divorced = 3,
}

export enum PagesRequried
{
    ThirtySix = 0,
    Sixty     = 1
}

export enum PassportType
{
    New = 0,
    Renewal = 1,
}

export enum PaymentStatus
{
    Unpaid = 0,
    Paid   = 1,
}

export enum ReasonforRenewal
{
    ValidityExpiredWithinThreeYears = 0,
    ChangeInExistingPersonal        = 1,
    ExhaustionOfPages               = 2,
    LostThePassport                 = 3,
    DamagedPassport                 = 4,        
}

export enum State
{
    AndamanAndNicobarIslands    = 0,
    AndhraPradesh               = 1,
    ArunachalPradesh            = 2,
    Assam                       = 3,
    Bihar                       = 4,
    Chandigarh                  = 5,
    Chhattisgarh                = 6,
    DadraAndNagarHaveli         = 7,
    DamanAndDiu                 = 8,
    Delhi                       = 9,
    Goa                         = 10,
    Gujarat                     = 11,
    Haryana                     = 12,
    HimachalPradesh             = 13,
    JammuAndKashmir             = 14,
    Jharkhand                   = 15,
    Karnataka                   = 16,
    Kerala                      = 17,
    Lakshadweep                 = 18,
    MadhyaPradesh               = 19,
    Maharashtra                 = 20,
    Manipur                     = 21,
    Meghalaya                   = 22,
    Mizoram                     = 23,
    Nagaland                    = 24,
    Odisha                      = 25,
    Puducherry                  = 26,
    Punjab                      = 27,
    Rajasthan                   = 28,
    Sikkim                      = 29,
    TamilNadu                   = 30,
    Telangana                   = 31,
    Tripura                     = 32,
    UttarPradesh                = 33,
    Uttarakhand                 = 34,
    WestBengal                  = 35
}

export enum ValidityRequired
{
    Ten          = 0,
    UptoEighteen = 1
}
export enum Gender {
    Male = 0,
    Female = 1,
    Transgender = 2
}