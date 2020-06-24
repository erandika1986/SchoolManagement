import { RoleModel } from './role.model';

export class UserModel {
    id: number;
    fullName: string;
    email: string;
    username: string;
    mobileNo: string;
    password: string;

    isActive: boolean;
    roles: RoleModel[];
}
