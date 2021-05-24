import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  sideMenu : any = [
    { name: "Dashboard", path : "/admin", icon: "fa fa-home"},
    {name:"whatsapp" ,path: "/whatsapp", icon:"fa fa-whatsapp"},
    { name: "Profile", path : "/my-profile", icon: "fa fa-user-circle"},
    { name: "facebook", path:"/facebook", icon: "fa fa-facebook"},
    { name: "instagram", path:"/Instagram", icon: "fa fa-instagram" },
  ]
  constructor() { }

  ngOnInit() {
  }

}
