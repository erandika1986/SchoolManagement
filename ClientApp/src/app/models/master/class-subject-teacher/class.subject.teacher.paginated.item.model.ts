import { PaginatedItemsModel } from '../../common/paginated-Items.model';
import { ClassSubjectTeacherBasicDetailModel } from './class.subject.teacher.basic.detail.model';


export class ClassSubjectTeacherPaginatedItemsModel extends PaginatedItemsModel {
    data: ClassSubjectTeacherBasicDetailModel[];
}