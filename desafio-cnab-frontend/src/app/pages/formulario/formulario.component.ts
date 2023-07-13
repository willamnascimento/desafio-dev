import { Component } from '@angular/core';
import { FileUploadService } from 'src/app/shared/file-upload.service';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.scss']
})
export class FormularioComponent{
  selectedFile: File | undefined;
  
  constructor(private fileUploadService: FileUploadService) {}
  
  onFileSelected(event: any){
    this.selectedFile = event.target.files[0];
    
  }
  
  uploadFile() {
    if (this.selectedFile) {
      this.fileUploadService.uploadFile(this.selectedFile).subscribe(
        response => {
          console.log('Arquivo enviado com sucesso!', response);
        },
        error => {
          console.error('Erro ao enviar arquivo:', error);
        }
        );
      }
    }
  }
  