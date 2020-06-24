import { RoleModel } from './role.model';

export class UserModel {
    id: number;
    fullName: string;
    email: string;
    nickName: string;
    username: string;
    mobileNo: string;
    password: string;

    isActive: boolean;
    roles: RoleModel[];
    LstUserRole: string;
}
