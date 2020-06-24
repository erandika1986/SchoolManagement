import { PaginatedItemsModel } from '../../common/paginated-Items.model';
import { AssessmentTypeModel } from './assessment-type.model';


export class AssessmentTypePaginatedItemsModel extends PaginatedItemsModel {
    data: AssessmentTypeModel[];
}