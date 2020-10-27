import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TimeTableModel } from '../../models/timetable/time.table.model';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { DropDownModel } from '../../models/common/drop-down.model';
import { ResponseModel } from '../../models/common/response.model';

@Injectable({
  providedIn: 'root'
})
export class TimeTableService {

  constructor(private httpClient: HttpClient) { }


  getAcademicYears(): Observable<DropDownModel[]> {
    return this.httpClient.get<DropDownModel[]>(environment.apiUrl + 'TimeTable/getAcademicYears');
  }

  getGeneratedTimeTables(academicYear: number): Observable<TimeTableModel[]> {
    return this.httpClient.get<TimeTableModel[]>(environment.apiUrl + 'TimeTable/getGeneratedTimeTables/' + academicYear);
  }


  generateTimeTable(): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'TimeTable/generateTimeTable', null);
  }
}
