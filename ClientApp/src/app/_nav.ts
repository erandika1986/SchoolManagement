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
            },
            {
                name: 'Academic Level',
                url: '/admin/academic-level',
                icon: 'icon-drop'
            },
            {
                name: 'Class Name',
                url: '/admin/class-name',
                icon: 'icon-drop'
            },
            {
                name: 'Subject',
                url: '/admin/subject',
                icon: 'icon-drop'
            },
            {
                name: 'Assessment Type',
                url: '/admin/assessment-type',
                icon: 'icon-drop'
            },
            {
                name: 'Student',
                url: '/admin/student',
                icon: 'icon-drop'
            },
            {
                name: 'Subject Teacher',
                url: '/admin/subject-teacher',
                icon: 'icon-drop'
            },
            {
                name: 'Class Teacher',
                url: '/admin/class-subject-teacher',
                icon: 'icon-drop'
            },
            {
                name: 'Academic Year',
                url: '/admin/academic-year',
                icon: 'icon-drop'
            }
        ]
    }
];
