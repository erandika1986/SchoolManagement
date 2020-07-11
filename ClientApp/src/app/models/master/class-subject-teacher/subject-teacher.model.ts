import { DropDownModel } from '../../common/drop-down.model';

export class SubjectTeacherModel {

    subjectTeachers: DropDownModel[];
    selectedSubjectId: number;
    selectedTeacherId: number;
    isvalid: boolean = true;
    validationMsg: string;


}
