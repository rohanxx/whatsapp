import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  currentUser;
  constructor(private route:Router) { }

  ngOnInit() {
    this.currentUser = localStorage.getItem('firstName');
  }

  navigate(url: any) {
    this.route.navigate([url]);
  }
}
