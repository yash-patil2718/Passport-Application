import { FeedbackType } from "../enums/feedbackType";


export interface FeedbackDTO {
    username        : string;        
    email           : string;       
    feedbackType    : FeedbackType; 
    description     : string;
}

  