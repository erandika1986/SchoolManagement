import { UserModel } from './user.model';
import { PaginatedItemsModel } from '../common/paginated-Items.model';

export class UserPaginatedItemsModel extends PaginatedItemsModel {
    data: UserModel[];
}
