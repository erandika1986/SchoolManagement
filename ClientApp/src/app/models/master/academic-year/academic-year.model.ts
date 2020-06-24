import { AcademicLevelModel } from '../academic-level/academic-level.model';

export class AcademicYearModel {
    id: number;
    academicYear: number;
    noOfClassess: number;
    total: number;
    isActive: boolean;
    createdOn: string;
    createdBy: string;
    updatedOn: string;
    updatedBy: string;

    academicLevelViewModels: AcademicLevelModel[]
}
