<template>
<div>
  <v-layout row wrap px-12 pt-12>
    <v-flex md12>
      <h1>Scanner</h1>
    </v-flex>
  </v-layout>

  <v-layout>
    <v-flex md12 pa-5>
    </v-flex>  
  </v-layout>

  <v-layout px-12>
    <v-flex md12>
      <v-card class="elevation-12" color="#FFFFFF">
        <v-card-text>
          <v-text-field
            label="Name"
            type="text"
            v-model="name"
            light
            :readonly="editMode"
          ></v-text-field>
          <v-text-field
            label="Description"
            type="text"
            v-model="description"
            light
            :readonly="editMode"
          ></v-text-field>
          <v-text-field
            label="Serial Number"
            type="text"
            v-model="serialNumber"
            light
            :readonly="editMode"
          ></v-text-field>
        </v-card-text>
      </v-card>
    </v-flex>
  </v-layout>

  <v-layout>
    <v-flex md12 pa-2>
    </v-flex>
  </v-layout> 

  <v-layout px-12>
    <v-flex md12>
      <v-btn @click="toggleEditMode" block color="#26B47F" dark>Accept</v-btn>  
    </v-flex>    
  </v-layout>

  <v-layout>
    <v-flex md12 pa-2>
    </v-flex>
  </v-layout> 

  <v-layout px-12>
    <v-flex md12>
      <v-btn @click="clear" block color="#CE1127" dark>Decline</v-btn>  
    </v-flex>    
  </v-layout>

  <v-layout>
    <v-flex md12 pa-2>
    </v-flex>
  </v-layout>
</div>
</template>

<script>
export default {
  data: () => ({
    name : "",
    description : "",
    serialNumber: "",
  }),
  methods:{
    clear(){
      this.name = ""
      this.description = ""
      this.serialNumber = ""
    }
  }
}
</script>

<style>

</style>