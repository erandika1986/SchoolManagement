import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TimeTableListComponent } from './time-table-list/time-table-list.component';


const routes: Routes = [
    {
        path: '',
        data: {
            title: 'TimeTable'
        },
        children: [
            {
                path: 'time-table-list',
                component: TimeTableListComponent,
                data: {
                    title: 'Time Tables'
                }
            }

        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class TimeTableRoutingModule { }