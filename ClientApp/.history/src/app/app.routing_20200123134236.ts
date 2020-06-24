import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// Import Containers
import { DefaultLayoutComponent } from './containers';
import { CoreLayoutComponent } from './containers/core-layout/core-layout/core-layout.component';

// export const routes: Routes = [
//   {
//     path: '',
//     redirectTo: 'home',
//     pathMatch: 'full'
//   },
//   {
//     path: '',
//     component: DefaultLayoutComponent,
//     children: [
//       {
//         path: 'home',
//         loadChildren: () => import('./modules/home/home.module').then(m => m.HomeModule)
//       },
//       {
//         path: 'admin',
//         loadChildren: () => import('./modules/admin/admin.module').then(m => m.AdminModule)
//       }
//     ]
//   }
// ];

// export const routes: Routes = [
//   {
//     path: '',
//     component: CoreLayoutComponent,
//     children: [
//       {
//         path: 'login',
//         loadChildren: () => import('./modules/login/login.module').then(m => m.LoginModule)
//       },
//       {
//         path: '',
//         component: DefaultLayoutComponent,
//         children: [
//           {
//             path: 'home',
//             loadChildren: () => import('./modules/home/home.module').then(m => m.HomeModule)
//           },
//           {
//             path: 'admin',
//             loadChildren: () => import('./modules/admin/admin.module').then(m => m.AdminModule)
//           }
//         ]
//       }
//     ]
//   }
// ];

// export const routes: Routes = [
//   {
//     path: '',
//     redirectTo: 'home',
//     pathMatch: 'full'
//   },
//   {
//     path: '',
//     component: DefaultLayoutComponent,
//     children: [
//       {
//         path: 'home',
//         loadChildren: () => import('./modules/home/home.module').then(m => m.HomeModule)
//       },
//       {
//         path: 'admin',
//         loadChildren: () => import('./modules/admin/admin.module').then(m => m.AdminModule)
//       },
//       {
//         path: 'login',
//         loadChildren: () => import('./modules/login/login.module').then(m => m.LoginModule)
//       }
//     ]
//   }
// ];

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path: '',
    loadChildren: () => import('./containers/core-layout/core-layout.module').then(m => m.CoreLayoutModule)
  },
  {
    path: 'login',
    loadChildren: () => import('./modules/login/login.module').then(m => m.LoginModule)
  },
  {
    path: 'home',
    children: [
      {
        path: 'home',
        loadChildren: () => import('./modules/home/home.module').then(m => m.HomeModule)
      },
      {
        path: 'admin',
        loadChildren: () => import('./modules/admin/admin.module').then(m => m.AdminModule)
      }
    ]
  }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
