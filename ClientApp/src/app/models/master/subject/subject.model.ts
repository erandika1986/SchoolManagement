
import { BasicSubjectModel } from '../common/basic-subject.model';
import { BasicAcademicLevel } from '../common/basic-academic-level.model';
import { DropDownModel } from '../../common/drop-down.model';

export class SubjectModel {
    id: number;
    name: string;
    subjectCode: string;
    isParentBasketSubject: boolean;
    isBasketSubject: boolean;
    subjectCategory: number;
    subjectStream: number;
    isActive: boolean;
    createdOn: Date;
    createdById: number;
    updatedOn: Date;
    updatedById: number;

    academicLevels: BasicAcademicLevel[];
    parentSubjectId: number;
    parentSubjects: BasicSubjectModel[];
    subjectStreams: DropDownModel[];
}
