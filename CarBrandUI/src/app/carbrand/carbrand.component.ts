import { Component, OnInit } from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';
import { Carbrand } from './carbrand';
import { FormBuilder, Validators } from '@angular/forms';
import { CarbrandService } from './carbrand.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-carbrand',
  templateUrl: './carbrand.component.html',
  styleUrls: ['./carbrand.component.css'],
})
export class CarbrandComponent implements OnInit {
  /**
   * Page grid row height.
   *
   * @type {string}
   * @memberof CarbrandComponent
   */
  rowHeight: string = '85vh';

  /**
   * Flag to indicate if new data has been saved.
   *
   * @type {boolean}
   * @memberof CarbrandComponent
   */
  dataSaved: boolean = false;

  /**
   * Form used to create a new car brand.
   *
   * @type {any}
   * @memberof CarbrandComponent
   */
  carBrandCreateForm: any;

  /**
   * Car brand image to be uploaded.
   *
   * @type {string}
   * @memberof CarbrandComponent
   */
  imageSrc: string;

  /**
   * Form used to search by car brand name.
   *
   * @type {any}
   * @memberof CarbrandComponent
   */
  carBrandSearchForm: any;

  /**
   * Car brand name retrieved from server.
   *
   * @type {string}
   * @memberof CarbrandComponent
   */
  retrievedName: string;

  /**
   * Car brand image retrieved from server.
   *
   * @type {string}
   * @memberof CarbrandComponent
   */
  retrievedImage: string;

  /**
   * Creates an instance of the carbrand.component.
   * @param breakpointObserver The breakpointObserver.
   * @param formbuilder The formbuilder.
   * @param carBrandService The carBrandService.
   */
  constructor(
    private breakpointObserver: BreakpointObserver,
    private formbuilder: FormBuilder,
    private carBrandService: CarbrandService
  ) {}

  /**
   * Action called on page initialization.
   */
  ngOnInit(): void {
    this.detectBreakpoint();

    this.carBrandCreateForm = this.formbuilder.group({
      Name: ['', [Validators.required]],
      Image: ['', [Validators.required]],
    });

    this.carBrandSearchForm = this.formbuilder.group({
      Name: ['', [Validators.required]],
    });
  }

  /**
   * Action called on submission of form to create car brand.
   */
  onCreateFormSubmit() {
    this.dataSaved = false;

    // Define Image as Base64 content
    this.carBrandCreateForm.value.Image = this.imageSrc;

    const carBrand = this.carBrandCreateForm.value;
    this.createCarBrand(carBrand);
  }

  /**
   * Action called when image is selected.
   * @param {any} e The event.
   */
  handleInputChange(e) {
    var file = e.dataTransfer ? e.dataTransfer.files[0] : e.target.files[0];
    var pattern = /image-*/;

    if (!file.type.match(pattern)) {
      alert('Invalid file format!');
      return;
    }

    var reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = this.handleReaderLoaded.bind(this);
  }

  /**
   * Action called on submission of form to search for car brand.
   */
  onSearchFormSubmit() {
    const carBrandName = this.carBrandSearchForm.value.Name;
    this.getCarBrandByName(carBrandName);

    // Reset Input boxes
    this.carBrandSearchForm.reset();
  }

  /**
   * Method to Get the Car Brand by Name.
   * @param {string} carBrandName The Car Brand Name.
   */
  private getCarBrandByName(carBrandName: string) {
    this.carBrandService.getCarBrandByName(carBrandName).subscribe(
      (carBrand) => {
        this.retrievedName = carBrand.name;
        this.retrievedImage = carBrand.image;
      },
      (error: HttpErrorResponse) => {
        alert(error.error);
      }
    );
  }

  /**
   * Method to Create the Car Brand.
   * @param {Carbrand} carBrand The Car Brand to be created.
   */
  private createCarBrand(carBrand: Carbrand) {
    this.carBrandService.createCarBrand(carBrand).subscribe(
      () => {
        this.dataSaved = true;
        alert(
          `Car brand '${this.carBrandCreateForm.value.Name}' created successfully!`
        );
        this.carBrandCreateForm.reset();
        this.imageSrc = '';
      },
      (error: HttpErrorResponse) => {
        alert(error.error);
      }
    );
  }

  /**
   * Method to handle the selected image.
   * @param {any} e The event.
   */
  private handleReaderLoaded(e) {
    let reader = e.target;
    this.imageSrc = reader.result;
  }

  /**
   * Method to handle page the page size.
   */
  private detectBreakpoint(): void {
    this.breakpointObserver
      .observe(['(max-width: 500px)'])
      .subscribe((result) => {
        this.rowHeight = result.matches ? '100vh' : '85vh';
      });
  }
}
