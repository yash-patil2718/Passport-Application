import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, of, switchMap } from 'rxjs';
import {  RenewApplicationData} from '../interfaces/form-interfaces';
import { NewApplicationData } from '../interfaces/new-form-interfaces';
import { environment } from '../../../environment/environment';
import { INewApplicationForm } from '../interfaces/INewapplication';
import { IApplicationDetails, IApplicationStatusDetails } from '../interfaces/applicationStatus';
import { IPaymentUpdateDto } from '../interfaces/paymentDto';


@Injectable({
  providedIn: 'root'
})
export class FormDataService {

  private apiUrl = environment.apiUrl; 

  constructor(private http: HttpClient) {}

  getAllNewApplication(): Observable<NewApplicationData[]>{
    return this.http.get<NewApplicationData[]>(`${this.apiUrl}/newApplications`);
  }
  getAllRenewApplication(): Observable<RenewApplicationData[]>{
    return this.http.get<RenewApplicationData[]>(`${this.apiUrl}/renewApplications`);
  }

  saveRenewApplication(applicationData: INewApplicationForm): Observable<INewApplicationForm> {
    return this.http.post<INewApplicationForm>(`${this.apiUrl}/RenewApplication/renewapplication`, applicationData);
  }
  saveNewApplication(applicationData: INewApplicationForm): Observable<INewApplicationForm> {
    return this.http.post<INewApplicationForm>(`${this.apiUrl}/NewApplication/newapplication`, applicationData);
  }

  getApplicationByNumber(applicationNumber: string, dob: string): Observable<RenewApplicationData | NewApplicationData> {
    return this.getAllNewApplication().pipe(
      map(newApps => {
        const app = newApps.find(app => app.applicationNumber === applicationNumber && app.applicant.dob === dob);
        if (app) {
          (app as any).applicationSource = 'new';
        }
        return app ? { ...app } : null;
      }),
      switchMap(newApp => {
        if (newApp) return of(newApp);
        return this.getAllRenewApplication().pipe(
          map(renewApps => {
            const app = renewApps.find(app => app.applicationNumber === applicationNumber && app.applicant.dob === dob);
            if (app) {
              (app as any).applicationSource = 'renew';
            }
            return app ? { ...app } : null;
          })
        );
      }),
      map(app => app as RenewApplicationData | NewApplicationData)
    );
  }

  updateApplication(applicationData: IApplicationDetails): Observable<IApplicationDetails> {
    return this.http.patch<IApplicationDetails>(`${this.apiUrl}/`, applicationData);
  }

  getApplicationByNumberApi( applicationData : IApplicationStatusDetails): Observable<IApplicationDetails> {
    return this.http.post<IApplicationDetails>(`${this.apiUrl}/ApplicationStatus/trackapplication`,applicationData);

  }

  makePaymentProcess(paymentDto : IPaymentUpdateDto) : Observable<string>{
    return this.http.put<string>(`${this.apiUrl}/Payment/payment`,paymentDto);
  }
}
