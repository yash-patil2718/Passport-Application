
export interface CustomerFeedback {
    isEditing?    : any;
    feedbackId    : number,
    email         : string,
    username      : string,
    description   : string,
    status        : number,
    feedbackType  : number,
    createdOn     : Date,
    updatedOn     : Date
  }