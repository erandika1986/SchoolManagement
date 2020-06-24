import { PaginatedItemsModel } from '../../common/paginated-Items.model';
import { SubjectModel } from './subject.model';


export class SubjectPaginatedItemsModel extends PaginatedItemsModel {
    data: SubjectModel[];
}