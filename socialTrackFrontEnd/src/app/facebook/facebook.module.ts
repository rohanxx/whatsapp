import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FacebookRoutingModule } from './facebook-routing.module';

import { FacebookChatComponent } from './facebook-chat/facebook-chat.component';


@NgModule({
  declarations: [ FacebookChatComponent],
  imports: [
    CommonModule,
    FacebookRoutingModule
  ]
})
export class FacebookModule { }
