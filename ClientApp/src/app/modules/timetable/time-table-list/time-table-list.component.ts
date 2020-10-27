import { Component, OnInit } from '@angular/core';
import { TimeTableService } from '../../../services/timetable/time-table.service';
import { DropDownModel } from '../../../models/common/drop-down.model';
import { TimeTableModel } from '../../../models/timetable/time.table.model';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-time-table-list',
  templateUrl: './time-table-list.component.html',
  styleUrls: ['./time-table-list.component.css']
})
export class TimeTableListComponent implements OnInit {

  academicYears: DropDownModel[] = [];
  selectedAcademicYearid: number;

  timeTables: TimeTableModel[] = [];

  constructor(private timeTableService: TimeTableService, private ngxSpinnerService: NgxSpinnerService
  ) { }

  ngOnInit(): void {

    this.ngxSpinnerService.show();
    this.getAcademicYears();
  }

  getAcademicYears() {
    this.timeTableService.getAcademicYears()
      .subscribe(response => {
        this.academicYears = response;
        this.selectedAcademicYearid = response[0].id;
        this.getAvailableTimeTables();
      }, error => {
        this.ngxSpinnerService.hide();
      });
  }

  getAvailableTimeTables() {
    this.ngxSpinnerService.show();
    this.timeTableService.getGeneratedTimeTables(this.selectedAcademicYearid)
      .subscribe(response => {
        this.timeTables = response;
        this.ngxSpinnerService.hide();
      }, error => {

        this.ngxSpinnerService.hide();
      })
  };

  generateTimeTable() {
    this.ngxSpinnerService.show();
    this.timeTableService.generateTimeTable()
      .subscribe(response => {
        this.ngxSpinnerService.hide();
        if (response.isSuccess) {
          Swal.fire(
            'Success!',
            response.message,
            'success'
          )
        }
        else {
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: response.message
          })
        }
      }, error => {
        this.ngxSpinnerService.hide();
      })
  }

  academicYearOnChange() {
    this.ngxSpinnerService.show();
    this.getAvailableTimeTables();
  }

  downloadTeachersTimeTable() {

  }

  downloadClassTimeTable() {

  }
}
