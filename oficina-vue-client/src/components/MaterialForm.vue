<template>
    <v-card>
      <v-card-title>
        {{ localMaterial.id ? 'Editar Material' : 'Novo Material' }}
      </v-card-title>
      <v-card-text>
        <v-form @submit.prevent="save">
          <v-text-field
            v-model="localMaterial.name"
            label="Nome"
            required
          ></v-text-field>
          <v-btn type="submit" color="primary">
            Salvar
          </v-btn>
          <v-btn @click="close" color="secondary" class="ml-2">
            Cancelar
          </v-btn>
        </v-form>
      </v-card-text>
    </v-card>
  </template>
  
  <script>
  export default {
    props: {
      material: {
        type: Object,
        required: true,
      },
    },
    data() {
      return {
        // Cria uma cópia local da prop
        localMaterial: { ...this.material },
      };
    },
    methods: {
      save() {
        // Emite o evento "save" com o material atualizado
        this.$emit('save', this.localMaterial);
      },
      close() {
        // Emite o evento "close" para fechar o diálogo
        this.$emit('close');
      },
    },
  };
  </script>