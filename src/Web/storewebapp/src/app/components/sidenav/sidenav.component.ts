import { Component, OnInit } from '@angular/core';
import { PoMenuItem } from '@po-ui/ng-components';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {

  
  constructor() {}
    
  ngOnInit(): void {
  }

  readonly menus: Array<PoMenuItem> = [
    { label: 'Produtos', link: '/produtos/lista'},
    { label: 'Categorias', link: '/categorias/lista'}
  ];

}
