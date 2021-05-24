import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComComponent } from './admin-com/admin-com.component';
import { ModalModule } from 'ngx-modal';
import { ShellModule } from '../shell/shell.module';


@NgModule({
  declarations: [AdminComComponent,
   
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    ModalModule,
    ReactiveFormsModule,
ShellModule
    
  ]
})
export class AdminModule { }
