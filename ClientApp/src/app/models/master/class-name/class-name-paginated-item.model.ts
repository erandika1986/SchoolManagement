import { PaginatedItemsModel } from '../../common/paginated-Items.model';
import { ClassNameModel } from './class-name.model';


export class ClassNamePaginatedItemsModel extends PaginatedItemsModel {
    data: ClassNameModel[];
}