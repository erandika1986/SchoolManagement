import { PaginatedItemsModel } from '../../common/paginated-Items.model';
import { AcademicLevelModel } from './academic-level.model';


export class AcademicLevelPaginatedItemsModel extends PaginatedItemsModel {
    data: AcademicLevelModel[];
}