import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environment/environment';
import { FeedbackDTO } from '../interfaces/FeedbackDTO';
import { CustomerFeedback } from '../interfaces/customerFeedback';

@Injectable({
  providedIn: 'root'
})
export class ComplainService {
  private apiUrl = environment.apiUrl; 

  constructor(private http: HttpClient) {}

  // Generate a random 6-digit ID
  private generateRandomId(): number {
    return Math.floor(100000 + Math.random() * 900000);
  }

  // Submit feedback
  submitFeedback(feedback: CustomerFeedback): Observable<CustomerFeedback> {
   // feedback.id = this.generateRandomId();
    return this.http.post<CustomerFeedback>(`${this.apiUrl}/feedbacks`, feedback);
  }

  // Submit complaint
  submitComplaint(complaint: CustomerFeedback): Observable<CustomerFeedback> {
   // complaint.id = this.generateRandomId();
    return this.http.post<CustomerFeedback>(`${this.apiUrl}/complaints`, complaint);
  }

  submitFeedbackComplaint(feedback: FeedbackDTO): Observable<FeedbackDTO>{
    return this.http.post<FeedbackDTO>(`${this.apiUrl}/Feedback/feedback`, feedback);
  }

}

