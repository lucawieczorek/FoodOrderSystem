import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { BottomBarComponent } from './bottom-bar/bottom-bar.component';
import { LoginComponent } from './login/login.component';
import { AdminUsersComponent } from './admin-users/admin-users.component';
import { AddUserComponent } from './add-user/add-user.component';
import { ChangeUserDetailsComponent } from './change-user-details/change-user-details.component';
import { OrderHomeComponent } from './order-home/order-home.component';
import { RestaurantSearchComponent } from './restaurant-search/restaurant-search.component';

import { AuthService } from './auth/auth.service';
import { SystemAdminAuthGuardService as SystemAdminAuthGuard } from './auth/system-admin-auth-guard.service';
import { RestaurantAdminAuthGuardService as RestaurantAdminAuthGuard } from './auth/restaurant-admin-auth-guard.service';
import { UserAdminService } from './user/user-admin.service';
import { ChangeUserPasswordComponent } from './change-user-password/change-user-password.component';
import { RemoveUserComponent } from './remove-user/remove-user.component';
import { PaginationComponent } from './pagination/pagination.component';
import { AdminCuisinesComponent } from './admin-cuisines/admin-cuisines.component';
import { AdminPaymentMethodsComponent } from './admin-payment-methods/admin-payment-methods.component';
import { AddCuisineComponent } from './add-cuisine/add-cuisine.component';
import { CuisineAdminService } from './cuisine/cuisine-admin.service';
import { ChangeCuisineComponent } from './change-cuisine/change-cuisine.component';
import { RemoveCuisineComponent } from './remove-cuisine/remove-cuisine.component';
import { AddPaymentMethodComponent } from './add-payment-method/add-payment-method.component';
import { ChangePaymentMethodComponent } from './change-payment-method/change-payment-method.component';
import { RemovePaymentMethodComponent } from './remove-payment-method/remove-payment-method.component';
import { PaymentMethodAdminService } from './payment-method/payment-method-admin.service';

@NgModule({
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      { path: '', component: OrderHomeComponent },
      { path: 'admin/users', component: AdminUsersComponent, canActivate: [SystemAdminAuthGuard] },
      { path: 'admin/cuisines', component: AdminCuisinesComponent, canActivate: [SystemAdminAuthGuard] },
      { path: 'admin/paymentmethods', component: AdminPaymentMethodsComponent, canActivate: [SystemAdminAuthGuard] },
    ]),
    ReactiveFormsModule,
    NgbModule,
    HttpClientModule,
  ],
  declarations: [
    AppComponent,
    PaginationComponent,
    TopBarComponent,
    BottomBarComponent,
    LoginComponent,
    AdminUsersComponent,
    AddUserComponent,
    ChangeUserDetailsComponent,
    ChangeUserPasswordComponent,
    RemoveUserComponent,
    AdminCuisinesComponent,
    AddCuisineComponent,
    ChangeCuisineComponent,
    RemoveCuisineComponent,
    AdminPaymentMethodsComponent,
    AddPaymentMethodComponent,
    ChangePaymentMethodComponent,
    RemovePaymentMethodComponent,
    OrderHomeComponent,
    RestaurantSearchComponent,
  ],
  providers: [
    AuthService,
    SystemAdminAuthGuard,
    RestaurantAdminAuthGuard,
    UserAdminService,
    CuisineAdminService,
    PaymentMethodAdminService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
