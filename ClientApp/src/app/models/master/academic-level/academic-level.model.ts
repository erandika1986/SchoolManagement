import { BasicClassModel } from './basic-class.model';

export class AcademicLevelModel {
    id: number;
    description: string;
    levelHeadId: number;
    levelHeadName: string;
    isActive: boolean;
    createdOn: Date;
    createdById: number;
    updatedOn: Date;
    updatedById: number;

    classes: BasicClassModel[];
}
