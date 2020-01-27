<template>
<div>
  <v-layout row wrap px-12 pt-12>
    <v-flex md12>
      <h1>View Container</h1>
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

  <v-layout v-if="editMode" px-12>
    <v-flex md12>
      <v-btn @click="toggleEditMode" block color="#CE1127">Update</v-btn>  
    </v-flex>    
  </v-layout>

  <v-layout v-else px-12>
    <v-flex md12>
      <v-btn @click="update" block color="#CE1127">Save</v-btn>  
    </v-flex>    
  </v-layout>

  <v-layout>
    <v-flex md12 pa-2>
    </v-flex>
  </v-layout>

  <v-layout v-if="editMode" px-12>
    <v-flex md12>
      <v-btn @click="deleteUser" block color="#CE1127">Delete User</v-btn>  
    </v-flex>    
  </v-layout>

  <v-layout v-if="editMode">
    <v-flex md12 pa-2>
    </v-flex>
  </v-layout> 

  <v-layout v-if="editMode" px-12>
    <v-flex md12>
      <v-btn to="/inventory" block color="#012a5e">Cancel</v-btn>  
    </v-flex>    
  </v-layout>

  <v-layout v-else px-12>
    <v-flex md12>
      <v-btn @click="toggleEditMode" block color="#012a5e">Cancel</v-btn>  
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
    editMode: true
  }),
  mounted(){
    this.getContainer()
  },
  methods :{
    getContainer(){
      this.$axios.$get('https://localhost:44367/api/containers/' + this.$route.params.id).then((result) => {
        this.name = result.name,
        this.description = result.description,
        this.serialNumber = result.serialNumber
      }).catch((err) => {
        console.log(err);
      });
    },
    deleteUser(){
      this.$axios.$delete('https://localhost:44367/api/containers/' + this.$route.params.id).then(() => {
        alert("Container deleted.")
        this.$nuxt.$router.replace({path : '/inventory'});
      }).catch((err) => {
        console.log(err);
      });
    },
    update(){
      this.$axios.$put('https://localhost:44367/api/containers/' + this.$route.params.id, {
        name : this.name,
        description : this.description,
        serialNumber : this.serialNumber,
      }).then((result) => {
        alert("Container updated.")
        this.$nuxt.$router.replace({path : '/inventory'});
      }).catch((err) => {
        console.log(err);
      });
    },
    toggleEditMode(){
      this.editMode = !this.editMode;
      if(this.editMode){
        this.getContainer();
      }
    }
  }
}
</script>

<style>

</style>