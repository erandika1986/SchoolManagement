import { INavData } from '@coreui/angular';
import { Component } from '@angular/core';

export const navItems: INavData[] = [
    {
        name: 'School Management',
        url: '/home',
        icon: 'icon-speedometer'
    },
    {
        name: 'Admin',
        url: '/admin',
        icon: 'icon-puzzle',
        children: [
            {
                name: 'User',
                url: '/admin/user',
                icon: 'icon-drop'
            }
        ]
    }
];
