import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FileUploadService } from 'src/app/shared/file-upload.service';
import { FormularioRoutingModule } from './formulario-routing.module';
import { FormularioComponent } from './formulario.component';

@NgModule({
    imports: [
        CommonModule, 
        FormularioRoutingModule],
    declarations: [
        FormularioComponent],
    providers: [
        FileUploadService]
})
export class FormularioModule {}
