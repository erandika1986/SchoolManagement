import { BasicAcademicLevel } from '../common/basic-academic-level.model';

export class AssessmentTypeModel {
    id: number;
    name: string;
    description: string;
    levels: string;

    isActive: boolean;
    createdOn: Date;
    createdById: number;
    updatedOn: Date;
    updatedById: number;

    academicLevels: BasicAcademicLevel[];
}
