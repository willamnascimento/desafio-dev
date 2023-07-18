import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormularioComponent } from './formulario.component';
import { FileUploadService } from 'src/app/shared/services/file-upload.service';
import { of } from 'rxjs';
import { HttpClientModule } from '@angular/common/http';

describe('FormularioComponent', () => {
  let component: FormularioComponent;   
  let fixture: ComponentFixture<FormularioComponent>;
  let fileUploadService: FileUploadService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientModule],
      declarations: [FormularioComponent],
      providers: [FileUploadService]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormularioComponent);
    component = fixture.componentInstance;
    fileUploadService = TestBed.inject(FileUploadService);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should set selectedFile when onFileSelected is called', () => {
    const file = new File(['file contents'], 'test-file.txt', { type: 'text/plain' });
    const event = { target: { files: [file] } } as any;

    component.onFileSelected(event);

    expect(component.selectedFile).toBe(file);
  });

  it('should call uploadFile on fileUploadService when uploadFile is called', () => {
    const file = new File(['file contents'], 'test-file.txt', { type: 'text/plain' });
    component.selectedFile = file;

    const uploadFileSpy = spyOn(fileUploadService, 'uploadFile').and.returnValue(of({}));

    component.uploadFile();

    expect(uploadFileSpy).toHaveBeenCalledWith(file);
  });
});
