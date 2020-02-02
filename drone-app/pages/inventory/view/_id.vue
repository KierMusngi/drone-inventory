<template>
<div>
  <v-layout row wrap px-12 pt-12>
    <v-flex md12>
      <h1 class="white--text">View Container</h1>
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
            readonly
          ></v-text-field>
          <v-text-field
            label="Description"
            type="text"
            v-model="description"
            light
            readonly
          ></v-text-field>
          <v-text-field
            label="Serial Number"
            type="text"
            v-model="serialNumber"
            light
            readonly
          ></v-text-field>
        </v-card-text>
      </v-card>
    </v-flex>
  </v-layout>

  <v-layout>
    <v-flex md12 pa-2>
    </v-flex>
  </v-layout> 

  <!-- <v-layout v-if="editMode" px-12>
    <v-flex md12>
      <v-btn @click="toggleEditMode" block color="#CE1127">Update</v-btn>  
    </v-flex>    
  </v-layout> -->

  <!-- <v-layout v-else px-12>
    <v-flex md12>
      <v-btn @click="update" block color="#CE1127">Save</v-btn>  
    </v-flex>    
  </v-layout> -->

  <v-layout>
    <v-flex md12 pa-2>
    </v-flex>
  </v-layout>

  <v-layout px-12>
    <v-flex md12>
      <v-btn 
        @click="deleteContainer" 
        block
        color="#CE1127" 
        dark
        rounded
      >Delete</v-btn>  
    </v-flex>    
  </v-layout>

  <v-layout>
    <v-flex md12 pa-2>
    </v-flex>
  </v-layout> 

  <!-- <v-layout v-if="editMode" px-12>
    <v-flex md12>
      <v-btn to="/inventory" block color="#012a5e">Cancel</v-btn>  
    </v-flex>    
  </v-layout>

  <v-layout v-else px-12>
    <v-flex md12>
      <v-btn @click="toggleEditMode" block color="#012a5e">Cancel</v-btn>  
    </v-flex>     
  </v-layout> -->

  <v-layout px-12>
    <v-flex md12>
      <v-btn 
        to="/inventory" 
        block 
        color="#26B47F" 
        dark
        rounded
      >Back</v-btn>  
    </v-flex>    
  </v-layout>

  <v-layout>
      <v-flex md12 pa-2>
      </v-flex>
    </v-layout>
  
   <v-snackbar
      v-model="snackbar"
      color="red"
      :timeout=2000
      top
    >
      {{ text }}
    </v-snackbar>
</div>
</template>

<script>
export default {
  data: () => ({
    name : "",
    description : "",
    serialNumber: "",
    snackbar: false,
    text: "Container successfully deleted."
  }),
  mounted(){
    this.getContainer()
  },
  methods :{
    getContainer(){
      this.$axios.$get(`${process.env.API_BASE_URL}/containers/` + this.$route.params.id).then((result) => {
        this.name = result.name,
        this.description = result.description,
        this.serialNumber = result.serialNumber
      }).catch((err) => {
        console.log(err);
      });
    },
    deleteContainer(){
      this.$axios.$delete(`${process.env.API_BASE_URL}/containers/` + this.$route.params.id).then(() => {
        this.snackbar = true
        setTimeout(() => {  this.$nuxt.$router.replace({path : '/inventory'}); }, 2000);
        // this.$nuxt.$router.replace({path : '/inventory'});
      }).catch((err) => {
        console.log(err);
      });
    },
    // update(){
    //   this.$axios.$put(`${process.env.API_BASE_URL}/containers/` + this.$route.params.id, {
    //     name : this.name,
    //     description : this.description,
    //     serialNumber : this.serialNumber,
    //   }).then((result) => {
    //     alert("Container updated.")
    //     this.$nuxt.$router.replace({path : '/inventory'});
    //   }).catch((err) => {
    //     console.log(err);
    //   });
    // },
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