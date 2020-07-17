import { Component, ViewChild, OnInit } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { Album, albums } from '../Models/Album';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'material-table',
  styleUrls: ['material-table.component.css'],
  templateUrl: 'material-table.component.html',
})
export class MaterialTableDemoComponent implements OnInit {
  displayedColumns = ['productName', 'productCode', 'prodRating', 'edit', 'delete'];
  products: Album[] = albums;
  dataSource = new MatTableDataSource(albums);
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort, {}) sort: MatSort;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  ngOnInit() {
    //this.dataSource = this.products;
    this.dataSource.paginator = this.paginator;

  }

  onNavigate(productCode) {
    console.log(`product code ${productCode}`)
  }

}
