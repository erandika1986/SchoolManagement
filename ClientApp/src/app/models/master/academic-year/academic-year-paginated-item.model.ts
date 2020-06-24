import { PaginatedItemsModel } from '../../common/paginated-Items.model';
import { AcademicYearModel } from './academic-year.model';



export class AcademicYearPaginatedItemsModel extends PaginatedItemsModel {
    data: AcademicYearModel[];
}