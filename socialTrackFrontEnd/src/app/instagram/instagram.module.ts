import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InstagramRoutingModule } from './instagram-routing.module';
import { InstagramChatComponent } from './instagram-chat/instagram-chat.component';


@NgModule({
  declarations: [InstagramChatComponent],
  imports: [
    CommonModule,
    InstagramRoutingModule
  ]
})
export class InstagramModule { }
