export class AssessmentTypeModel {
    id: number;
    description: string;
    startMonth: number;
    endMonth: number;

    isActive: boolean;
    createdOn: Date;
    createdById: number;
    updatedOn: Date;
    updatedById: number;
}
